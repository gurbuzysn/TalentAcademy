﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Features.Queries.Student.GetAllStudent;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.Features.Queries.Students.GetAllStudent
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQueryRequest, List<GetAllStudentsQueryResponse>>
    {
        private readonly IReadRepository<TalentAcademy.Domain.Entities.Identitiy.Student> _readRepository;
        private readonly IMapper _mapper;

        public GetAllStudentsQueryHandler(IReadRepository<TalentAcademy.Domain.Entities.Identitiy.Student> repository, IMapper mapper)
        {
            _readRepository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetAllStudentsQueryResponse>> Handle(GetAllStudentsQueryRequest request, CancellationToken cancellationToken)
        {
            var students = await _readRepository.GetAllAsync();
            var studentsResponse = _mapper.Map<List<GetAllStudentsQueryResponse>>(students);

            return studentsResponse;
        }
    }
}