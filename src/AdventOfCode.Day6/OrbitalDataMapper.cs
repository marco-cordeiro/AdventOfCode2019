using AdventOfCode.Data.Provider;
using AdventOfCode.OrbitalNavigation;

namespace AdventOfCode.Day6
{
    public class OrbitalDataMapper
    {
        private readonly IDataProvider<string> _provider;
        private readonly IOrbitalMapFactory _mapFactory;

        public OrbitalDataMapper(IDataProvider<string> provider, IOrbitalMapFactory mapFactory)
        {
            _provider = provider;
            _mapFactory = mapFactory;
        }

        public OrbitalMap Load()
        {
            while (!_provider.Eof)
            {
                var data = _provider.Read();
                var parts = data.Split(')');

                _mapFactory.AddOrbit(parts[1]).Around(parts[0]);
            }

            return _mapFactory.Build();
        }
    }
}