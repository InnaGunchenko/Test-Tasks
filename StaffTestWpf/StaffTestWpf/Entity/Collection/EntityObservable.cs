using StaffTestWpf.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace StaffTestWpf.Entity.Collection
{
    public class EntityChangedEventArgs<TEntity> : EventArgs
    {
        public TEntity Item { get; set; }
    }

    public class EntityObservable<TEntity> : ObservableCollection<TEntity> where TEntity : INotifyPropertyChanged
    {
        public event EntityChangedEventHandler ItemChanged;
        public delegate void EntityChangedEventHandler(object sender, EntityChangedEventArgs<TEntity> args);

        public EntityObservable()
            : base()
        {
            this.CollectionChanged += new NotifyCollectionChangedEventHandler(observable_CollectionChanged);
        }

        public EntityObservable(List<TEntity> entities)
            : this()
        {
            foreach (TEntity entity in entities)
            {
                this.Add(entity);
            }
        }

        void observable_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (TEntity item in e.NewItems)
                    item.PropertyChanged += new PropertyChangedEventHandler(observable_ItemChanged);
            }
        }

        void observable_ItemChanged(object sender, PropertyChangedEventArgs e)
        {
            EntityChangedEventArgs<TEntity> args = new EntityChangedEventArgs<TEntity>();
            args.Item = (TEntity)sender;
            ItemChanged(this, args);
        }
    }
}