﻿using System;
using System.Collections.Generic;

namespace Wesley.Client.Models.Products
{
    public partial class StatisticalTypeListModel
    {
        public StatisticalTypeListModel()
        {

        }

        public string Name { get; set; }


        public IList<StatisticalTypeModel> Items { get; set; }
    }


    //typeof(StatisticalTypeValidator))]
    public partial class StatisticalTypeModel : EntityBase
    {

        //("键名", "键名
        public string Name { get; set; }


        //("键值", "键值
        public string Value { get; set; }

        /// <summary>
        /// 创建时间
        //("创建时间", "创建时间
        public DateTime CreatedOnUtc { get; set; }

    }
}