﻿// Copyright (c) Microsoft. All rights reserved.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.KernelMemory.AI;

/// <summary>
/// Interface to generate a list of embedding vectors, used by LLMs that support batch requests.
/// This is used to limit the number of API calls, making the process faster and reduce the risk of throttling.
/// </summary>
public interface ITextEmbeddingBatchGenerator
{
    /// <summary>
    /// This indicates the maximum number of elements that can be processed in a single batch. Some of
    /// the models have not only a limit in the number of tokens but also have a limit in the number
    /// of elements that can be sent in a single batch.
    /// </summary>
    int MaxBatchSize { get; }

    /// <summary>
    /// Generates embeddings for a list of text chunks.
    /// </summary>
    /// <param name="textList">The list of text chunks to process.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Array of embedding vectors</returns>
    Task<Embedding[]> GenerateEmbeddingBatchAsync(
        IEnumerable<string> textList,
        CancellationToken cancellationToken = default);
}
