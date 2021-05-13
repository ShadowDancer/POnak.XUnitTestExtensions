# POnak.XUnitTestExtensions

Collection of test case generators for common test patterns

## Quickstart

Use attributes to specify data boundaries:

```csharp
[Theory]
[IntInclusiveBoundaryData(0, 100)]
public void TestIntInclusiveBoundary(bool expectedPass, int value)
{
    ClassUnderTest test = new ClassUnderTest();
    bool success = test.Between0And100(value);

    Assert.Equal(expectedPass, success);
}
```

This will generate following test cases:

```csharp
TestIntInclusiveBoundary(false, -10 - 1)

// Low boundary
TestIntInclusiveBoundary(false, -10)

TestIntInclusiveBoundary(true, -10 + 1)

// Middle point
TestIntInclusiveBoundary(true, 0)

TestIntInclusiveBoundary(true, 10 - 1)

 // High boundary
TestIntInclusiveBoundary(false, 10)

TestIntInclusiveBoundary(false, 10 + 1)
```
