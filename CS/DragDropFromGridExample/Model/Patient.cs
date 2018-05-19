#region #usings
using DevExpress.Mvvm.POCO;
using System;
#endregion #usings

namespace DragDropFromGridExample {
    public class Patient {
        public static Patient Create() {
            return ViewModelSource.Create(() => new Patient());
        }

        protected Patient() {
        }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string Phone { get; set; }
    }
}
