﻿using System.Web.Mvc;

namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// ComboboxItemDto扩展
    /// </summary>
    public static class ComboboxItemDtoExtensions
    {
        public static SelectListItem ToSelectListItem(this ComboboxItemDto comboboxItem)
        {
            return new SelectListItem
            {
                Value = comboboxItem.Value,
                Text = comboboxItem.DisplayText,
                Selected = comboboxItem.IsSelected
            };
        }
    }
}
