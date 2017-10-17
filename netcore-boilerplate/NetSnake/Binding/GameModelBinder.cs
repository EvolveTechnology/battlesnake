using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetSnake.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetSnake.Binding
{
    public class GameModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            string valueFromBody;

            using (var sr = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                valueFromBody = sr.ReadToEnd();
            }

            if (string.IsNullOrEmpty(valueFromBody))
            {
                return Task.CompletedTask;
            }

            var result = new Game();
            var json = JObject.Parse(valueFromBody);

            if (json["game_id"] != null)
            {
                result.Id = Guid.Parse(json["game_id"].ToString());
            }

            if (json["height"] != null)
            {
                result.Height = int.Parse(json["height"].ToString());
            }

            if (json["width"] != null)
            {
                result.Width = int.Parse(json["width"].ToString());
            }

            if (json["you"] != null)
            {
                result.MySnakeId = Guid.Parse(json["you"].ToString());
            }

            if (json["turn"] != null)
            {
                result.Turn = int.Parse(json["turn"].ToString());
            }

            if (json["food"] != null)
            {
                var foodList = JsonConvert.DeserializeObject<IList<IList<int>>>(json["food"].ToString());

                foreach (var food in foodList)
                {
                    result.Food.Add(new Point { X = food[0], Y = food[1] });
                }
            }

            if (json["snakes"] != null)
            {
                var snakeList = JArray.Parse(json["snakes"].ToString());

                foreach (var jsonSnake in snakeList)
                {
                    var snakeId = Guid.Parse(jsonSnake["id"].ToString());
                    result.Snakes.Add(new Snake
                    {
                        Id = snakeId,
                        Coordinates = JsonConvert.DeserializeObject<IList<IList<int>>>(jsonSnake["coords"].ToString()).Select(x => new Point
                        {
                            X = x[0],
                            Y = x[1]
                        }).ToList(),
                        Health = int.Parse(jsonSnake["health_points"].ToString()),
                        Name = jsonSnake["name"].ToString(),
                        Taunt = jsonSnake["taunt"].ToString()
                    });
                }
            }

            if (json["dead_snakes"] != null)
            {
                var deadSnakeList = JArray.Parse(json["dead_snakes"].ToString());

                foreach (var jsonDeadSnake in deadSnakeList)
                {
                    result.Snakes.Add(new Snake
                    {
                        Id = Guid.Parse(jsonDeadSnake["id"].ToString()),
                        Coordinates = JsonConvert.DeserializeObject<IList<IList<int>>>(jsonDeadSnake["coords"].ToString()).Select(x => new Point
                        {
                            X = x[0],
                            Y = x[1]
                        }).ToList(),
                        Health = int.Parse(jsonDeadSnake["health_points"].ToString()),
                        Name = jsonDeadSnake["name"].ToString(),
                        Taunt = jsonDeadSnake["taunt"].ToString()
                    });
                }
            }

            bindingContext.Result = ModelBindingResult.Success(result);

            return Task.CompletedTask;
        }
    }
}