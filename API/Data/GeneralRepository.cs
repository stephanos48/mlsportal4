using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Migrations
{
    public class GeneralRepository
    {
                private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GeneralRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //TxQoh Methods

        public async Task<IEnumerable<MasterPart>> GetMasterPartAsync()
        {
            var txqohs = await _context.MasterParts.ToListAsync();
            return txqohs;
        }

        public async Task<MasterPart> GetMasterPart(int id)
        {
            var specificpn = await _context.MasterParts.FirstOrDefaultAsync(m => m.MasterPartId == id);
            return specificpn;
        }

        public void DeleteMasterPart(MasterPart masterPart)
        {
            _context.MasterParts.Remove(masterPart);
        }

        //PoPlan Methods
/*
        public async Task<IEnumerable<PoPlan>> GetPoPlansAsync()
        {
            var poplans = await _context.PoPlans.ToListAsync();
            return poplans;
        }

        public async Task<PoPlan> GetPoPlan(int id)
        {
            var poplanspecific = await _context.PoPlans.FirstOrDefaultAsync(m => m.PoPlanId == id);
            return poplanspecific;
        }

        public async Task<IEnumerable<PoPlan>> GetNotReceived()
        {
            var poplans = await _context.PoPlans.Where(x=>x.PoOrderStatus != "Closed/Received").Where(y=>y.PoOrderStatus != "Transit").ToListAsync();
            return poplans;
        }

        public async Task<IEnumerable<PoPlan>> GetReceived()
        {
            var poplans = await _context.PoPlans.Where(x=>x.PoOrderStatus == "Closed/Received").ToListAsync();
            return poplans;
        }

        public async Task<IEnumerable<PoPlan>> GetTransit()
        {
            var poplans = await _context.PoPlans.Where(x=>x.PoOrderStatus == "Transit").ToListAsync();
            return poplans;
        }

        public void DeletePoPlan(PoPlan poPlan)
        {
            _context.PoPlans.Remove(poPlan);
        }

        //SoPlan Methods

        public async Task<IEnumerable<SoPlan>> GetSoPlansAsync()
        {
            var soplans = await _context.SoPlans.ToListAsync();
            return soplans;
        }

        public async Task<IEnumerable<SoPlan>> GetOpenSoPlansAsync()
        {
            var soplans = await _context.SoPlans.Where(x=>x.ShipPlanStatus != "Closed/Shipped")
            .Where(y=>y.ShipPlanStatus != "Slotted")
            .Where(z=>z.ShipPlanStatus != "Closed/Canceled")
            .Where(x=>x.ShipPlanStatus != "OrderToCancel")
            .ToListAsync();
            return soplans;
        }

        public async Task<SoPlan> GetSoPlan(int id)
        {
            var soplanspecific = await _context.SoPlans.FirstOrDefaultAsync(m => m.SoPlanId == id);
            return soplanspecific;
        }

        public async Task<IEnumerable<SoPlan>> GetShipOuts()
        {
            var soplans = await _context.SoPlans.Where(x=>x.ShipPlanStatus == "Closed/Shipped").ToListAsync();
            return soplans;
        }

        public async Task<IEnumerable<SoPlan>> GetSlotted()
        {
            var soplans = await _context.SoPlans.Where(x=>x.ShipPlanStatus == "Slotted").ToListAsync();
            return soplans;
        }

        public void DeleteSoPlan(SoPlan soPlan)
        {
            _context.SoPlans.Remove(soPlan);
        }

        //Quote Methods

        public async Task<IEnumerable<Quote>> GetQuotesAsync()
        {
            var quotes = await _context.Quotes.ToListAsync();
            return quotes;
        }

        public async Task<Quote> GetQuote(int id)
        {
            var quote = await _context.Quotes.FirstOrDefaultAsync(m => m.QuoteId == id);
            return quote;
        }

        public void DeleteQuote(Quote quote)
        {
            _context.Quotes.Remove(quote);
        }

        //QuoteDetail Methods

        public async Task<IEnumerable<QuoteDetail>> GetQuoteDetailsAsync()
        {
            var quotedetails = await _context.QuoteDetails.ToListAsync();
            return quotedetails;
        }

        public async Task<QuoteDetail> GetQuoteDetail(int id)
        {
            var quotedetail = await _context.QuoteDetails.FirstOrDefaultAsync(m => m.QuoteDetailId == id);
            return quotedetail;
        }

        public void DeleteQuoteDetail(QuoteDetail quoteDetail)
        {
            _context.QuoteDetails.Remove(quoteDetail);
        }

        //Supplier Methods

        public async Task<IEnumerable<Supplier>> GetSuppliersAsync()
        {
            var suppliers = await _context.Suppliers.ToListAsync();
            return suppliers;
        }

        public async Task<Supplier> GetSupplier(int id)
        {
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(m => m.SupplierId == id);
            return supplier;
        }

        public void DeleteSupplier(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
        }
*/
    }
    
}