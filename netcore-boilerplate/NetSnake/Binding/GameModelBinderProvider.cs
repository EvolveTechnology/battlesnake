using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NetSnake.Binding
{
    public class GameModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return new GameModelBinder();
        }
    }
}