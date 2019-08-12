﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Abp.TestBase.SampleApplication.People.Dto
{
    [AbpAutoMap(typeof(Person))]
    public class PersonDto : EntityDto
    {
        public int ContactListId { get; set; }

        public string Name { get; set; }
    }
}