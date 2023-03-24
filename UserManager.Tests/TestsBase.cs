using System.Reflection;

namespace UserManager.Tests
{
    public class TestsBase
    {
        protected void AssertEqual(object mockData, object actualData)
        {
            foreach (PropertyInfo mockProperty in mockData.GetType().GetProperties())
            {
                PropertyInfo? actualProperty = actualData.GetType().GetProperties().Where(x => x.Name == mockProperty.Name).FirstOrDefault();

                if (actualProperty != null)
                {
                    if (mockProperty.Name == actualProperty.Name)
                    {
                        object? mockValue = mockProperty.GetValue(mockData);
                        object? actualValue = actualProperty.GetValue(actualData);

                        if (mockValue != null && actualValue != null)
                        {
                            if (mockValue.GetType().Equals(typeof(Int64)))
                                Assert.Equal(actualValue.ToString(), mockValue.ToString());
                            else
                                Assert.Equal(actualValue, actualValue);
                        }                        
                    }
                }                
            }
        }
    }
}
