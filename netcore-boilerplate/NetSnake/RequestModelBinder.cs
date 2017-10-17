using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NetSnake
{
    public class RequestModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var key = "Point";
            var val = bindingContext.ValueProvider.GetValue(key);
            //if (val != null)
            //{
            //    var s = val.AttemptedValue as string;
            //    if (s != null)
            //    {
            //        var points = s.Split(',');
            //        bindingContext.Model = new Models.MyRequest
            //        {
            //            Point = new Models.Coordinate
            //            {
            //                X = Convert.ToDecimal(points[0],
            //                    CultureInfo.InvariantCulture),
            //                Y = Convert.ToDecimal(points[1],
            //                    CultureInfo.InvariantCulture)
            //            }
            //        };
            //        return true;
            //    }
            //}
            return Task.FromResult(false);
        }
    }
}
