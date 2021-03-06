﻿using Noleggio.Common;
using Noleggio.Common.Contracts;
using Noleggio.DbModels;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace Noleggio.DtoModels.RentItems
{
    public class RentItemDtoModel : IMapFrom<RentItem>, IHaveCustomMappings
    {
        private IList<ImagesDtoModel> images;

        public RentItemDtoModel()
        {
            this.images = new List<ImagesDtoModel>();
        }
        public string OwnerId { get; set; }

        public string ItemId { get; set; }

        [Required(ErrorMessage = "{0}тое задължително")]
        [Display(Name = "Име")]
        [MaxLength(NoleggioConstants.RentItemNameMaximumLength)]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "{0}ът е задължителен")]
        [Display(Name = "Място")]
        [MaxLength(NoleggioConstants.RentItemLocationMaximumLength)]
        public string Location { get; set; }

        [Required(ErrorMessage = "{0}то е задължително")]
        [Display(Name = "Описание")]
        [MaxLength(NoleggioConstants.CommentMaxLength)]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} е задължителна")]
        [DataType(DataType.Date)]
        [Display(Name = "Начална Дата")]
        public DateTime AvailableFrom { get; set; }

        [Required(ErrorMessage = "{0} е задължителна")]
        [DataType(DataType.Date)]
        [Display(Name = "Крайна Дата")]
        public DateTime AvailableTo { get; set; }

        [Required(ErrorMessage = "{0} е задължителна")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Цена на Ден")]
        public Decimal Price { get; set; }

        public IList<ImagesDtoModel> Images
        {
            get
            {
                return this.images;
            }
            set
            {
                this.images = value;
            }
        }

        public string CategoryId { get; set; }

        public virtual void CreateMappings(IMapperConfigurationExpression config)
        {

            config.CreateMap<RentItem,RentItemDtoModel >()
                             .ForMember(s => s.ItemId, opt => opt.MapFrom(d => d.Id));


        }
    }
}