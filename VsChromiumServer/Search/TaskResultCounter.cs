﻿// Copyright 2013 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

namespace VsChromiumServer.Search {
  /// <summary>
  /// Note: Instances of this class are technically not thread safe, but it is
  /// nonetheless ok to call them from multiple thread concurrently, as the worst
  /// that can happen is that parallel tasks will run a bit too much.
  /// This is assuming of course this class is only used to bound the number of results
  /// returned by tasks run in parallel.
  /// </summary>
  public class TaskResultCounter {
    private readonly int _maxResults;
    private int _count;

    public TaskResultCounter(int maxResults) {
      this._maxResults = maxResults;
    }

    public bool Done {
      get {
        return this._count >= this._maxResults;
      }
    }

    public void Add(int count) {
      this._count += count;
    }

    public void Increment() {
      Add(1);
    }
  }
}
