using Mobile_Store_MS.ViewModel.ModelsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Interfaces
{
    public interface IModelRepositery
    {
        List<ModelViewModel> GetDetails();
        ModelViewModel GetDetail(int id);
        int addModel(ModelViewModel c);
        int Update(EditViewModel emp);
        bool delete(int id);

    }
}
