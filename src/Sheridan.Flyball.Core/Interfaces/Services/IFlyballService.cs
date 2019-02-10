using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.ViewModels.Create;
using Sheridan.Flyball.Core.ViewModels.Update;

namespace Sheridan.Flyball.Core.Interfaces.Services
{
    [SuppressMessage("ReSharper", "TypeParameterCanBeVariant")]
    public interface IFlyballService<TModel,TCreateModel,TUpdateModel>
    {
        Task<TModel> Create(TCreateModel newModel);
        Task<TModel> GetById(int id);
        Task<TModel> Update(TUpdateModel updateModel);
        Task<IList<TModel>> All();
    }
}
