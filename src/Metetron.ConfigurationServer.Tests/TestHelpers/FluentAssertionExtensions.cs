using System.Text.RegularExpressions;
using FluentAssertions;
using FluentAssertions.Collections;
using FluentValidation.Results;

namespace Metetron.ConfigurationServer.Tests.TestHelpers
{
    public static class FluentAssertionExtensions
    {
        public static AndConstraint<GenericCollectionAssertions<ValidationFailure>> ContainValidationErrorFor(this GenericCollectionAssertions<ValidationFailure> assertion, string propertyName)
        {
            return assertion.Contain(fv => fv.PropertyName.Equals(propertyName));
        }

        public static AndConstraint<GenericCollectionAssertions<ValidationFailure>> NotContainValidationErrorFor(this GenericCollectionAssertions<ValidationFailure> assertion, string propertyName)
        {
            return assertion.NotContain(fv => fv.PropertyName.Equals(propertyName));
        }

        public static AndConstraint<GenericCollectionAssertions<ValidationFailure>> ContainValidationErrorForChild(this GenericCollectionAssertions<ValidationFailure> assertion, string propertyName)
        {
            return assertion.Contain(fv => Regex.IsMatch(fv.PropertyName, $@"{propertyName}\[[0-9]+\]"));
        }

        public static AndConstraint<GenericCollectionAssertions<ValidationFailure>> NotContainValidationErrorForChild(this GenericCollectionAssertions<ValidationFailure> assertion, string propertyName)
        {
            return assertion.Contain(fv => !Regex.IsMatch(fv.PropertyName, $@"{propertyName}\[[0-9]+\]"));
        }
    }
}