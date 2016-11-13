using System.Collections.Generic;

namespace DataBase.Objects
{
	public interface BaseTable
	{

        string Name { get; }
        Dictionary<int, Column> Columns { get; }

    }
}

