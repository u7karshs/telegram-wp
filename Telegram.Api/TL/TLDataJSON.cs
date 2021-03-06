﻿// 
// This is the source code of Telegram for Windows Phone v. 3.x.x.
// It is licensed under GNU GPL v. 2 or later.
// You should have received a copy of the license in this archive (see LICENSE).
// 
// Copyright Evgeny Nadymov, 2013-present.
// 
using System.Collections.Generic;
using System.IO;
using Telegram.Api.Extensions;

namespace Telegram.Api.TL
{
    public class TLDataJSON : TLUpdateBase
    {
        public const uint Signature = TLConstructors.TLDataJSON;

        public TLString Data { get; set; }

        public override TLObject FromBytes(byte[] bytes, ref int position)
        {
            bytes.ThrowExceptionIfIncorrect(ref position, Signature);

            Data = GetObject<TLString>(bytes, ref position);

            return this;
        }

        public override byte[] ToBytes()
        {
            return TLUtils.Combine(
                TLUtils.SignatureToBytes(Signature),
                Data.ToBytes());
        }

        public override void ToStream(Stream output)
        {
            output.Write(TLUtils.SignatureToBytes(Signature));
            Data.ToStream(output);
        }

        public override TLObject FromStream(Stream input)
        {
            Data = GetObject<TLString>(input);

            return this;
        }

        public override IList<TLInt> GetPts()
        {
            return new List<TLInt>();
        }
    }
}
