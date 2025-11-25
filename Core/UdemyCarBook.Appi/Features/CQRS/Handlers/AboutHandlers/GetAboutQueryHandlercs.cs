using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Appi.Interfaces;
using UdemyCarBook.Application.Features.CQRS.Results.AboutResults;
using UdemyCarBookDomain.Entities;


namespace UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandlercs
    {
        private readonly IRepository<About> _repository;

        public GetAboutQueryHandlercs(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task< List<GetAboutByIdQueryResult>>Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAboutByIdQueryResult
            {
                AboutID = x.AboutID,
                Description = x.Description,
                Title = x.Title,
                ImageUrl = x.ImageUrl,
            }).ToList();

        }

    }
}
