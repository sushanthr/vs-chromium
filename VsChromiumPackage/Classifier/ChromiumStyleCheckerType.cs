﻿// Copyright 2013 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace VsChromiumPackage.Classifier {
  internal static class VsChromiumPackageClassificationDefinition {
    /// <summary>
    /// Defines the "VsChromiumPackage" classification type.
    /// </summary>
    [Export(typeof(ClassificationTypeDefinition))]
    [Name("VsChromiumPackage")]
    internal static ClassificationTypeDefinition VsChromiumPackageType = null;
  }
}
