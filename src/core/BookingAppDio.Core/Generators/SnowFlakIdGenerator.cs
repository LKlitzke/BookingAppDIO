using IdGen;

namespace BookingAppDio.Core.Generators
{
    public static class SnowFlakIdGenerator
    {
        private static IdGenerator _idGenerator;

        public static void Configure(int generatorId)
        {
            var epoch = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Local);

            // 45 bits for timestamp, 2 bits for generator-id, and 16 bits for sequence number
            var structure = new IdStructure(45, 2, 16);

            var options = new IdGeneratorOptions(structure, new DefaultTimeSource(epoch));

            _idGenerator = new IdGenerator(generatorId, options);
        }

        public static long NewId() => _idGenerator.CreateId();
    }
}