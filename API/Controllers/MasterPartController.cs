using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class MasterPartController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoService _photoService;

        public MasterPartController(IUnitOfWork unitOfWork, IMapper mapper, IPhotoService photoService )
        {
            _photoService = photoService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("getMasterParts")]
        public async Task<IActionResult> GetMasterParts()
        {

            var txqohs = await _unitOfWork.GeneralRepository.GetMasterPartAsync();

            var txqohsToReturn = _mapper.Map<IEnumerable<MPForReturnDto>>(txqohs);

            return Ok(txqohsToReturn);
        }

        [HttpGet("getActualQohs")]
        public async Task<IActionResult> GetActualQohs()
        {
            //List<TxQoh> txhold = new List<TxQoh>();
            //List<PoPlan> pohold = new List<PoPlan>();
            //List<SoPlan> sohold = new List<SoPlan>();

            var txqohs = await _unitOfWork.GeneralRepository.GetMasterPartAsync();
            //var poplans = await _unitOfWork.GeneralRepository.GetPoPlansAsync();
            //var soplans = await _unitOfWork.GeneralRepository.GetSoPlansAsync();

            var startDate = DateTime.Parse("1/1/2020");
            var query = from tx in txqohs
                        //join r in poplans.Where(a=>a.ReceiptDateTime >= startDate).Where(y=>y.PoOrderStatus == "Closed/Received") on tx.Pn equals r.CustomerPn into g
                        //join ru in soplans.Where(a=>a.ShipDateTime >= startDate).Where(y=>y.ShipPlanStatus == "Closed/Shipped") on tx.Pn equals ru.CustomerPn into gr
                        orderby tx.PartNumber                        
                        select new
                        {
                            Id = tx.MasterPartId,
                            PartNumber = tx.PartNumber,
                            MlsPn = tx.MlsPn,
                            Customer = tx.CustomerId,
                            Jan1Qoh = tx.Qoh,
                            //Jan1Rec = (int?)g.Select(x => x.ReceivedQty).DefaultIfEmpty(0).Sum(),
                            //Jan1Ship = (int?)gr.Select(x => x.ShipQty).DefaultIfEmpty(0).Sum(),
                            //Qoh = tx.Qoh + (int?)g.Select(x => x.ReceivedQty).DefaultIfEmpty(0).Sum() - (int?)gr.Select(x => x.ShipQty).DefaultIfEmpty(0).Sum(),

                            Notes = tx.Notes
                        };

                List<MPForReturnDto> txhold = new List<MPForReturnDto>();
                foreach(var qoh in query.ToList())
                {
                    txhold.Add(new MPForReturnDto
                    {

                        MasterPartId = qoh.Id,
                        PartNumber = qoh.PartNumber,
                        MlsPn = qoh.MlsPn,
                        //Customer = qoh.Customer,
                        Jan1Qoh = qoh.Jan1Qoh,
                        //Jan1Rec = qoh.Jan1Rec,
                        //Jan1Ship = qoh.Jan1Ship,
                        //Qoh = qoh.Qoh,
                        //Location = qoh.Location,
                        Notes = qoh.Notes

                    });
                }

            return Ok(txhold);
        }
      
        [HttpGet("{id}", Name = "getMasterPart")]
        public async Task<IActionResult> GetMasterPart(int id)
        {
            var txqohFromRepo = await _unitOfWork.GeneralRepository.GetMasterPart(id);

            var txqohToReturn = _mapper.Map<MPForReturnDto>(txqohFromRepo);

            return Ok(txqohToReturn);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMasterPart(int id, MPForUpdateDto mpForUpdateDto)
        {
            var txqohFromRepo = await _unitOfWork.GeneralRepository.GetMasterPart(id);

            _mapper.Map(mpForUpdateDto, txqohFromRepo);

            if (await _unitOfWork.GeneralRepository.SaveAll())
                return NoContent();

            throw new Exception($"Updating MasterPart {id} failed on save");    
        }

        [HttpPost("createMasterPart")]
        public async Task<ActionResult> CreateMasterPart([FromBody]MPForCreationDto mPForCreationDto)
        {
            if (ModelState.IsValid)
            {
                var txqohToCreate = _mapper.Map<MasterPart>(mPForCreationDto);
                _unitOfWork.GeneralRepository.Add(txqohToCreate);

                if (await _unitOfWork.GeneralRepository.SaveChangesAsync())
                {
                var txqohToReturn = _mapper.Map<MPForReturnDto>(txqohToCreate);
                return CreatedAtRoute("GetMasterPart", 
                        new { controller = "MasterPart", id = txqohToCreate.MasterPartId }, txqohToReturn);
                }
                else
                {
                    return BadRequest("Failed to save changes to the database.");
                }   
            }

            return BadRequest(ModelState);

            /*if (await _repo.SaveAll()) {
                var customerToRetun = _mapper.Map<CustomerForReturnDto>(customer);
                return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, customerToRetun);
            }*/  
        }

        /*
        [HttpPost("editCustomer/{customerId}")]
        public async Task<IActionResult> Edit(int customerId, CustomerEditDto customerEditDto)
        {
            if (customerId != customerEditDto.CustomerId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var customerToEdit = _mapper.Map<Customer>(customerEditDto);
                    _repo.Add(customerToEdit);
                    await _repo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Customer(customerEditDto.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(customerEditDto);
            }
            return Ok();
        }
        */

        /*
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var value = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
            return Ok(value);
        }
        */

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMasterPart(int id)
        {
            var txqohToDelete = await _unitOfWork.GeneralRepository.GetMasterPart(id);
            
            _unitOfWork.GeneralRepository.DeleteMasterPart(txqohToDelete);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Problem deleting the message");
        }

        [HttpPost("{masterPartId}/add-photo")]
        public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file, int masterPartId)
        {
            //var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());
            var masterPart = await _unitOfWork.GeneralRepository.GetMasterPart(masterPartId);

            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null) return BadRequest(result.Error.Message);

            var photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            //if (user.Photos.Count == 0)
            //{
            //    photo.IsMain = true;
            //}

            masterPart.Photos.Add(photo);

             if (await _unitOfWork.Complete())
            {
                // return _mapper.Map<PhotoDto>(photo);
                //return CreatedAtRoute("GetUser", new { username = user.UserName }, _mapper.Map<PhotoDto>(photo));
                return CreatedAtRoute("GetPart", new { masterPartId = masterPart.MasterPartId }, _mapper.Map<PhotoDto>(photo));
            }

            return BadRequest("Problem addding photo");
        }

        [HttpPut("set-main-photo/{photoId}")]
        public async Task<ActionResult> SetMainPhoto(int photoId, int id)
        {
            //var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());
            var part = await _unitOfWork.GeneralRepository.GetMasterPart(id);
            
            var photo = part.Photos.FirstOrDefault(x => x.Id == photoId);

            if (photo.IsMain) return BadRequest("This is already your main photo");

            var currentMain = part.Photos.FirstOrDefault(x => x.IsMain);
            if (currentMain != null) currentMain.IsMain = false;
            photo.IsMain = true;

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to set main photo");
        }

        [HttpDelete("delete-photo/{photoId}")]
        public async Task<ActionResult> DeletePhoto(int photoId, int id)
        {
            //var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());
            var part = await _unitOfWork.GeneralRepository.GetMasterPart(id);

            var photo = part.Photos.FirstOrDefault(x => x.Id == photoId);

            if (photo == null) return NotFound();

            if (photo.IsMain) return BadRequest("You cannot delete your main photo");

            if (photo.PublicId != null)
            {
                var result = await _photoService.DeletePhotoAsync(photo.PublicId);
                if (result.Error != null) return BadRequest(result.Error.Message);
            }

            part.Photos.Remove(photo);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to delete the photo");
        }

    }
}