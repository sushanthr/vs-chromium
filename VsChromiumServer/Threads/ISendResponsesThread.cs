﻿// Copyright 2013 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

using VsChromiumCore.Ipc;

namespace VsChromiumServer.Threads {
  /// <summary>
  /// Abstraction of a thread sending responses to an instance of IIpcStream.
  /// </summary>
  public interface ISendResponsesThread {
    void Start(IIpcStream ipcStream);
    void WaitOne();
  }
}
