﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Commands.Courses.RemoveCourse
{
    public class RemoveCourseCommandHandler : IRequestHandler<RemoveCourseCommandRequest>
    {
        private readonly IReadRepository<Course> _readRepository;
        private readonly IWriteRepository<Course> _writeRepository;
        private readonly IMapper _mapper;

        public RemoveCourseCommandHandler(IReadRepository<Course> readRepository, IWriteRepository<Course> writeRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }
        public async Task Handle(RemoveCourseCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedCourse = await _readRepository.GetByIdAsync(request.Id);
            if (deletedCourse != null)
            {
                deletedCourse.DeletedDate = DateTime.UtcNow;
                await _writeRepository.RemoveAsync(deletedCourse);
            }
        }
    }
}