﻿using AutoMapper;
using MediatR;
using TalentAcademy.Application.Features.Queries.Student.GetStudentById;
using TalentAcademy.Application.Repositories;

namespace TalentAcademy.Application.Features.Queries.Students.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQueryRequest, GetStudentByIdQueryResponse>
    {
        private readonly IReadRepository<TalentAcademy.Domain.Entities.Identitiy.Student> _readRepository;
        private readonly IMapper _mapper;

        public GetStudentByIdQueryHandler(IReadRepository<TalentAcademy.Domain.Entities.Identitiy.Student> repository, IMapper mapper)
        {
            _readRepository = repository;
            _mapper = mapper;
        }
        public async Task<GetStudentByIdQueryResponse> Handle(GetStudentByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var selectedStudent = await _readRepository.GetByIdAsync(request.Id);
            var studentResponse = _mapper.Map<GetStudentByIdQueryResponse>(selectedStudent);

            return studentResponse;
        }
    }
}
