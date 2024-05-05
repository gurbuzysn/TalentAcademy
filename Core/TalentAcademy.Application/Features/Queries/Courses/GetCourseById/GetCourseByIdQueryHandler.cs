using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Queries.Courses.GetCourseById
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQueryRequest, GetCourseByIdQueryResponse>
    {
        private readonly IReadRepository<Course> _readRepository;
        private readonly IMapper _mapper;

        public GetCourseByIdQueryHandler(IReadRepository<Course> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<GetCourseByIdQueryResponse> Handle(GetCourseByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var course = await _readRepository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<GetCourseByIdQueryResponse>(course);
        }
    }
}
