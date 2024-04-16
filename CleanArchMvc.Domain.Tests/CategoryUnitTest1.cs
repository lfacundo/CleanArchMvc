using System;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Xunit;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidaState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Invalid State")]
        public void CreateCategory_WithInvalidParameters_ResultObjectInvalidState()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id Value");
        }

        [Fact(DisplayName = "Create Category With Short Name")]
        public void CreateCategory_WithShortName_ResultObjectInvalidState()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Nothing Name")]
        public void CreateCategory_WithNothingName_ResultObjectInvalidState()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Category With Null Name")]
        public void CreateCategory_WithNullName_ResultObjectInvalidState()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }
    }
}
