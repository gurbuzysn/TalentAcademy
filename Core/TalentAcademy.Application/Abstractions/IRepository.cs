﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Abstractions
{
    public interface IRepository<T> where T : class, new()
    {
        DbSet<T> Table { get; }
    }
}
