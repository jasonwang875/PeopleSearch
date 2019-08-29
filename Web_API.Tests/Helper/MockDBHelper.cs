
using Rhino.Mocks;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HealthCatalystApp.Tests.Helper
{
    public static class MockDBHelper
    {
        public static IDbSet<T> GetMockDbSet<T>(IList<T> data) where T : class
        {
            IQueryable<T> queryable = data.AsQueryable();

            IDbSet<T> mockDbSet = MockRepository.GenerateMock<IDbSet<T>, IQueryable>();

            mockDbSet.Stub(m => m.Provider).Return(queryable.Provider);
            mockDbSet.Stub(m => m.Expression).Return(queryable.Expression);
            mockDbSet.Stub(m => m.ElementType).Return(queryable.ElementType);
            mockDbSet.Stub(m => m.GetEnumerator()).Return(queryable.GetEnumerator());

            return mockDbSet;
        }
    }
}
