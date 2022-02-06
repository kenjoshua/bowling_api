namespace domain_project.domain.SeedWork
{
    using System;

    public abstract class BaseEntity
    {
        int? _requestedHashCode;
        int _Id;
        public virtual int Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }

    }
}
