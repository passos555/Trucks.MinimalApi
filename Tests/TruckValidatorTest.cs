using FluentValidation.TestHelper;
using Minimal.Enums;
using Minimal.Models;
using Minimal.Validators;
using NUnit.Framework;

namespace Minimal.Tests;

[TestFixture]
public class TruckValidatorTest
{
    private TruckValidator validator;

    [SetUp]
    public void Setup()
    {
        validator = new TruckValidator();
    }

    [Test]
    public void ValidateManufacturingDate_WithRuleIsRequired_IsValid()
    {
        var model = new Truck { ManufacturingDate = DateTime.Now };
        var result = validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(truck => truck.ManufacturingDate);
    }

    [Test]
    public void ValidateManufacturingDate_WithRuleIsRequired_IsInvalid()
    {
        var model = new Truck { };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(truck => truck.ManufacturingDate);
    }

    [Test]
    public void ValidateManufacturingDate_WithRuleYearIsValid_IsValid()
    {
        var model = new Truck { ManufacturingDate = DateTime.Now };
        var result = validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(truck => truck.ManufacturingDate.Year);
    }

    [Test]
    [TestCase("2020-1-1")]
    [TestCase("2099-1-1")]
    public void ValidateManufacturingDate_WithRuleYearIsValid_IsInvalid(DateTime date)
    {
        var model = new Truck { ManufacturingDate = date };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(truck => truck.ManufacturingDate.Year);
    }

    [Test]
    public void ValidateModelDate_WithRuleIsRequired_IsValid()
    {
        var model = new Truck { ModelDate = DateTime.Now };
        var result = validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(truck => truck.ModelDate);
    }

    [Test]
    public void ValidateModelDate_WithRuleIsRequired_IsInvalid()
    {
        var model = new Truck { };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(truck => truck.ModelDate);
    }

    [Test]
    public void ValidateModelDate_WithRuleYearIsValid_IsValid()
    {
        var model = new Truck { ModelDate = DateTime.Now };
        var result = validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(truck => truck.ModelDate.Year);
    }

    [Test]
    [TestCase("2020-1-1")]
    [TestCase("2099-1-1")]
    public void ValidateModelDate_WithRuleYearIsValid_IsInvalid(DateTime date)
    {
        var model = new Truck { ModelDate = date };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(truck => truck.ModelDate.Year);
    }

    [Test]
    public void ValidateModel_WithRuleIsRequired_IsValid()
    {
        var model = new Truck { Model = EModel.FH };
        var result = validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(truck => truck.Model);
    }

    [Test]
    public void ValidateModel_WithRuleIsRequired_IsInvalid()
    {
        var model = new Truck { };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(truck => truck.Model);
    }

    [Test]
    [TestCase(EModel.FH)]
    [TestCase(EModel.FM)]
    public void ValidateModel_WithRuleIsRequired_IsValid(EModel truckModel)
    {
        var model = new Truck { Model = truckModel };
        var result = validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(truck => truck.Model);
    }

    [Test]
    [TestCase(3)]
    [TestCase(4)]
    public void ValidateModel_WithRuleIsRequired_IsInvalid(int truckModel)
    {
        var model = new Truck { Model = (EModel)truckModel };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(truck => truck.Model);
    }
}
