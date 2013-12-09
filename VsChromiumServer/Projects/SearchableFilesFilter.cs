﻿// Copyright 2013 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

using VsChromiumCore.Configuration;
using VsChromiumCore.FileNames;

namespace VsChromiumServer.Projects {
  public class SearchableFilesFilter : ISearchableFilesFilter {
    private readonly PathPatternsFile _ignorePatternsFile;
    private readonly PathPatternsFile _includePatternsFile;

    public SearchableFilesFilter(IConfigurationSectionProvider configurationSectionProvider) {
      this._ignorePatternsFile = new PathPatternsFile(configurationSectionProvider, ConfigurationSectionNames.SearchableFilesIgnore);
      this._includePatternsFile = new PathPatternsFile(configurationSectionProvider, ConfigurationSectionNames.SearchableFilesInclude);
    }

    public bool Include(string fileName) {
      if (this._ignorePatternsFile.GetPathMatcher().MatchFileName(fileName, SystemPathComparer.Instance))
        return false;
      return this._includePatternsFile.GetPathMatcher().MatchFileName(fileName, SystemPathComparer.Instance);
    }
  }
}
