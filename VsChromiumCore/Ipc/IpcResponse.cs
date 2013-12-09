﻿// Copyright 2013 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

using ProtoBuf;

namespace VsChromiumCore.Ipc {
  [ProtoContract]
  [ProtoInclude(10, typeof(IpcEvent))]
  public class IpcResponse : IpcMessage {
  }
}
