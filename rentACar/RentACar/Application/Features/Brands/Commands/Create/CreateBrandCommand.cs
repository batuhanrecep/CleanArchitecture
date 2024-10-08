﻿using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand : IRequest<CreatedBrandResponse>, ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string Name { get; set; }

    //For Removing Cache
    public string CacheKey => "";
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetBrands"; //for cache group

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
        }

        public async Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            //Without mapper
            //Brand brand = new();
            //brand.Name = request.Name;
            //brand.Id = Guid.NewGuid();

            //var result =await _brandRepository.AddAsync(brand);
            //CreatedBrandResponse createdBrandResponse = new();
            //createdBrandResponse.Id = result.Id;
            //createdBrandResponse.Name = result.Name;

            //With Mapper

            await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(request.Name);

            Brand brand = _mapper.Map<Brand>(request);
            brand.Id = Guid.NewGuid();

            await _brandRepository.AddAsync(brand);

            //To test our transaction implementation
            //await _brandRepository.AddAsync(brand);


            CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(brand);

            return createdBrandResponse;
        }
    }
}

