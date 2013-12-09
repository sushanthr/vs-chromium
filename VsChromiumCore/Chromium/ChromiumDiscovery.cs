﻿// Copyright 2013 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

using System.Collections.Generic;
using System.Linq;
using VsChromiumCore.Configuration;
using VsChromiumCore.FileNames;
using VsChromiumCore.FileNames.PatternMatching;
using VsChromiumCore.Win32.Files;

namespace VsChromiumCore.Chromium {
  public class ChromiumDiscovery : IChromiumDiscovery {
    private readonly IPathPatternsFile _chromiumEnlistmentPatterns;

    public ChromiumDiscovery(IConfigurationSectionProvider configurationSectionProvider) {
      this._chromiumEnlistmentPatterns = new PathPatternsFile(configurationSectionProvider, ConfigurationFilenames.ChromiumEnlistmentDetectionPatterns);
    }

    public void ValidateCache() {
      // Nothing to do
    }

    public FullPathName GetEnlistmentRoot(FullPathName filename) {
      var directory = filename.Parent;
      if (!directory.DirectoryExists)
        return default(FullPathName);

      return EnumerateParents(filename)
        .FirstOrDefault(x => IsChromiumSourceDirectory(x, this._chromiumEnlistmentPatterns));
    }

    private IEnumerable<FullPathName> EnumerateParents(FullPathName path) {
      var directory = path.Parent;
      for (var parent = directory; parent != default(FullPathName); parent = parent.Parent) {
        yield return parent;
      }
    }

    public static bool IsChromiumSourceDirectory(FullPathName path, IPathPatternsFile chromiumEnlistmentPatterns) {
      // We need to ensure that all pattern lines are covered by at least one file/directory of |path|.
      IList<string> directories;
      IList<string> files;
      NativeFile.GetDirectoryEntries(path.FullName, out directories, out files);
      return chromiumEnlistmentPatterns.GetPathMatcherLines()
          .All(item => MatchFileOrDirectory(item, directories, files));
    }

    private static bool MatchFileOrDirectory(IPathMatcher item, IEnumerable<string> directories, IEnumerable<string> files) {
      return
        directories.Any(d => item.MatchDirectoryName(d, SystemPathComparer.Instance)) ||
        files.Any(f => item.MatchFileName(f, SystemPathComparer.Instance));
    }
  }
}
