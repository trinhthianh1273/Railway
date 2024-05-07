using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Commons.Interfaces;

public interface IDomainEventDispatcher
{
	Task DispatchAndClearEvents(IEnumerable<BaseEntity> entitiesWithEvents);
}
