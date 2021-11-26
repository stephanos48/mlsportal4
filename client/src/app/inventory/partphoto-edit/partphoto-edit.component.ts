import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { take } from 'rxjs/operators';
import { MasterPart } from 'src/app/_models/masterPart';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';
import { GeneralService } from 'src/app/_services/general.service';
import { environment } from 'src/environments/environment';
import { Photo } from 'src/app/_models/photo';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-partphoto-edit',
  templateUrl: './partphoto-edit.component.html',
  styleUrls: ['./partphoto-edit.component.css']
})
export class PartphotoEditComponent implements OnInit {
  @Input() masterPart: MasterPart;
  uploader: FileUploader;
  hasBaseDropzoneOver = false;
  baseUrl = environment.apiUrl;
  user: User;

  constructor(private route: ActivatedRoute, private accountService: AccountService, private memberService: MembersService, private generalService: GeneralService) {
    this.generalService.currentMasterPart$.pipe(take(1)).subscribe(masterPart => this.masterPart = masterPart);
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.initializeUploader();
  }

  fileOverBase(e: any) {
    this.hasBaseDropzoneOver = e;
  }

  setMainPhoto(photo: Photo) {
    this.generalService.setMainPhoto(photo.id).subscribe(() => {
      this.masterPart.photoUrl = photo.url;
      this.generalService.setCurrentMasterPart(this.masterPart);
      this.masterPart.photoUrl = photo.url;
      this.masterPart.photos.forEach(p => {
        if (p.isMain) p.isMain = false;
        if (p.id === photo.id) p.isMain = true;
      })
    })
  } 

  deletePhoto(photoId: number) {
    this.generalService.deletePhoto(photoId).subscribe(() => {
      this.masterPart.photos = this.masterPart.photos.filter(x => x.id !== photoId);
    })
  }

  initializeUploader() {
    this.uploader = new FileUploader({  
      url: this.baseUrl + 'masterPart/' + this.masterPart.masterPartId + '/add-photo',
      authToken: 'Bearer ' + this.user.token,
      isHTML5: true,
      allowedFileType: ['image', 'pdf'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    }
  
    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        const photo: Photo = JSON.parse(response);
        this.masterPart.photos.push(photo);
        if (photo.isMain) {
          this.user.photoUrl = photo.url;
          this.masterPart.photoUrl = photo.url;
          //this.accountService.setCurrentUser(this.user);
        }
    }
  
  }
}

}
