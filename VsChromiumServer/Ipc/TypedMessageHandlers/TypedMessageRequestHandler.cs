﻿// Copyright 2013 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

using VsChromiumCore.Ipc.TypedMessages;

namespace VsChromiumServer.Ipc.TypedMessageHandlers {
  public abstract class TypedMessageRequestHandler : ITypedMessageRequestHandler {
    public bool CanProcess(TypedRequest request) {
      var name = GetType().Name;
      return (request.GetType().Name + "Handler") == name;
    }

    public abstract TypedResponse Process(TypedRequest typedRequest);
  }
}