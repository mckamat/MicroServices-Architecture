﻿using FreeCourse.Shared.Services.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeCourse.Shared.Services.Concrete
{
	public class SharedIdentityService : ISharedIdentityService
	{
		private IHttpContextAccessor _contextAccessor;
		public SharedIdentityService(IHttpContextAccessor contextAccessor)
		{
			_contextAccessor = contextAccessor;
		}

		public string GetUserId => _contextAccessor.HttpContext.User.FindFirst("sub").Value; 
	}
}
