﻿using System.Threading;
using SmartAdmin.Data.Models;
using URF.Core.Abstractions.Trackable;
using URF.Core.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;

// Sample to extend ProductService, scoped to only ProductService vs. application wide
namespace SmartAdmin.Service
{
  public class CompanyService : Service<Company>, ICompanyService
  {
    public CompanyService(ITrackableRepository<Company> repository) : base(repository)
    {
    }

    // Example, adding synchronous Single method
    public Company Single(Expression<Func<Company, bool>> predicate)
    {
      return this.Repository.Queryable().Single(predicate);
    }
  }
}
