﻿//using Arctium.Connection.Tls.Protocol;
//using Arctium.Connection.Tls.Protocol.RecordProtocol;
//using System;
//using System.IO;
//using Arctium.Connection.Tls.Protocol.BinaryOps.FixedOps;
//using Arctium.Connection.Tls.Protocol.FormatConsts;
//using Arctium.Connection.Tls.ProtocolStream.RecordsLayer.RecordsLayer11.CryptoTransform;
//using Arctium.Connection.Tls.CryptoConfiguration;

//namespace Arctium.Connection.Tls.ProtocolStream.RecordsLayer.RecordsLayer11
//{
//    ///<summary>Record Layer</summary>
//    class _RecordLayer11
//    {
//        SecParams11 currentSecParams;
//        RecordFragmentReader fragmentsStream;
//        RecordIO recordIO;
//        Fragmentator fragmentator;
//        TlsRecordTransform tlsCiphertextTransform;

//        private _RecordLayer11(RecordIO recordIO, SecParams11 secParams)
//        {
//            currentSecParams = secParams;
//            fragmentator = new Fragmentator();
//            fragmentsStream = new RecordFragmentReader();
//            this.recordIO = recordIO;
//        }

//        public static _RecordLayer11 Initialize(RecordIO recordIO)
//        {
//            SecParams11 initSecParams = InitSecParams();
//            _RecordLayer11 recordLayer = new  _RecordLayer11(recordIO, initSecParams);
//            recordLayer.ChangeCipherSpec(initSecParams);

//            return recordLayer;
//        }

//        private static SecParams11 InitSecParams()
//        {
//            SecParams11 initParams = new SecParams11();
//            initParams.KeyReadSecret = new byte[0];
//            initParams.KeyWriteSecret = new byte[0];
//            initParams.MacReadSecret = new byte[0];
//            initParams.MacWriteSecret = new byte[0];
//            initParams.RecordCryptoType = new RecordCryptoType(CipherType.Stream, BlockCipherMode.CBC, BulkCipherAlgorithm.NULL, 0, MACAlgorithm.NULL);

//            return initParams;
//        }
        
//        ///<summary>
//        ///Change the current <see cref="SecurityParameters"/> state to new one. 
//        ///After this operation all read and write operations will be base on new state.
//        ///</summary>
//        public void ChangeCipherSpec(SecParams11 newParameters)
//        {
//            currentSecParams = newParameters;

//            TlsRecordTransformFactory tctFactory = new TlsRecordTransformFactory();
//            TlsRecordTransform newTransform = tctFactory.BuildTlsRecordTransform(newParameters);

//            this.tlsCiphertextTransform = newTransform;
//        }

//        ///<summary>
//        ///Divides, compress, encrypt and sends the higher level protocol bytes to the inner stream based on 
//        ///the current <see cref="SecurityParameters"/> state.
//        ///</summary>
//        public void Write(byte[] buffer, int offset, int count, ContentType type)
//        {
//            if (count == 0) throw new Exception("invalid count param. Must be at least one byte length ");

//            // divite to 2^14 blocks
//            // encrypt 
//            // compress

            
//            byte[][] buffers = fragmentator.SplitToFragments(buffer, offset, count);

//            for (int i = 0; i < buffers.Length; i++)
//            {
//                byte[] transformedFragment = 
//                    tlsCiphertextTransform.ForwardTransform(buffers[i], 0, buffers[i].Length, recordIO.WriteCount - 1, type);
//                recordIO.WriteFragment(transformedFragment, 0, transformedFragment.Length, type);
//            }

            
//        }

//        ///<summary>Reads bytes of the higher level protocol</summary>
//        public int Read(byte[] buffer, int offset, int count, out ContentType contentType)
//        {
//            if (!fragmentsStream.CanRead)
//                LoadFragmentToFragmentsStream();

//            return fragmentsStream.ReadFragment(buffer, offset, count, out contentType);
//        }

//        private void LoadFragmentToFragmentsStream()
//        {
//            int recordLength = recordIO.LoadRecord();
//            byte[] tempBuf = new byte[recordLength];

//            recordIO.ReadFragment(tempBuf, 0);


//            byte[] fragmentContent = tlsCiphertextTransform.ReverseTransform(tempBuf, 5, recordLength - 5, recordIO.ReadCount - 1, FixedRecordInfo.GetContentType(tempBuf, 0));

//            fragmentsStream.AppendFragment(fragmentContent, 0, fragmentContent.Length, FixedRecordInfo.GetContentType(tempBuf, 0));
//        }
//    }
//}