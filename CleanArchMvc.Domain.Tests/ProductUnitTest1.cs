using System;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Xunit;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidaState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Invalid State")]
        public void CreateProduct_WithInvalidParameters_ResultObjectInvalidState()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id Value");
        }

        [Fact(DisplayName = "Create Product With Short Name")]
        public void CreateProduct_WithShortName_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Ca", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Nothing Name")]
        public void CreateProduct_WithNothingName_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Product With Invalid Price")]
        public void CreateProduct_WithInvalidPrice_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Create Product", "Product Description", -9.99m, 99, "product image");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Theory(DisplayName = "Create Product With Invalid Stock")]
        [InlineData(-5)]
        public void CreateProduct_WithInvalidStock_ResultObjectInvalidState(int value)
        {
            Action action = () => new Product(1, "Create Product", "Product Description", 9.99m, value, "product image");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Fact(DisplayName = "Create Product With Null Image")]
        public void CreateProduct_WithNullImage_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Create Product", "Product Description", 9.99m, 99, null);
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Null Reference")]
        public void CreateProduct_WithNullImage_NoReferenceException()
        {
            Action action = () => new Product(1, "Create Product", "Product Description", 9.99m, 99, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }
    }
}
