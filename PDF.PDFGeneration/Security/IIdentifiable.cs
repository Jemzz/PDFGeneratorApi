using System;

namespace PDF.PDFGeneration.Security
{
    /// <summary>
    /// Identifiable interface used for policy authorization
    /// </summary>
    public interface IIdentifiable
    {
        /// <summary>
        /// Unique Identifier for policy.
        /// </summary>
        Guid Identifier { get; }
    }
}
