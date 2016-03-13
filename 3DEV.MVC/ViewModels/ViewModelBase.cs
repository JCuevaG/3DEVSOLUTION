using _3DEV.MVC.Models;

namespace _3DEV.MVC.ViewModels
{
    public class ViewModelBase
    {
        public bool? _canEdit = null;
        public bool? _canDelete = null;

        private RoleEvaluator _evaluator = new RoleEvaluator();

        public bool CanEdit
        {
            get
            {
                if (!this._canEdit.HasValue)
                {
                    this._canEdit = this._evaluator.CanEdit;
                }

                return this._canEdit.Value;
            }
        }

        public bool CanDelete
        {
            get
            {
                if (!this._canDelete.HasValue)
                {
                    this._canDelete = this._evaluator.CanDelete;
                }

                return this._canDelete.Value;
            }
        }

    }
}