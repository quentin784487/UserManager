using System.Reflection;

namespace UserManager.Tests
{
    public class TestsBase
    {
        protected void AssertEqual(object mockData, object actualData)
        {
            foreach (PropertyInfo mockProperty in mockData.GetType().GetProperties())
            {
                PropertyInfo actualProperty = actualData.GetType().GetProperties().Where(x => x.Name == mockProperty.Name).FirstOrDefault();

                if (actualProperty != null)
                {
                    if (mockProperty.Name == actualProperty.Name)
                    {
                        if (mockProperty.GetValue(mockData).GetType().Equals(typeof(Int64)))
                            Assert.Equal(actualProperty.GetValue(actualData).ToString(), mockProperty.GetValue(mockData).ToString());
                        else
                            Assert.Equal(actualProperty.GetValue(actualData), mockProperty.GetValue(mockData));
                    }
                }                
            }
        }
    }
}
