﻿using System.IO;
using System.Linq;
using Dicom;
using Dicom.Network;
using Dicom.Log;

namespace Store.DICOM.Dump
{
    using System;

    public class CEchoScp : DicomService, IDicomServiceProvider, IDicomCEchoProvider
    {
        public CEchoScp(Stream stream, Logger log) : base(stream, log, null)
        {
        }

        public void OnReceiveAssociationRequest(DicomAssociation association)
        {
            if (association.CalledAE != "STORESCP")
            {
                SendAssociationReject(DicomRejectResult.Permanent, DicomRejectSource.ServiceUser, DicomRejectReason.CalledAENotRecognized);
                return;
            }

            foreach (var pc in association.PresentationContexts.Where(pc => pc.AbstractSyntax == DicomUID.VerificationSOPClass))
            {
                pc.AcceptTransferSyntaxes(new[] {
                                                    DicomTransferSyntax.ExplicitVRLittleEndian,
                                                    DicomTransferSyntax.ExplicitVRBigEndian,
                                                    DicomTransferSyntax.ImplicitVRLittleEndian
                                                });
            }

            SendAssociationAccept(association);
        }

        public void OnReceiveAssociationReleaseRequest()
        {
            SendAssociationReleaseResponse();
        }

        public void OnReceiveAbort(DicomAbortSource source, DicomAbortReason reason)
        {
        }

        public void OnConnectionClosed(Exception exception)
        {
        }

        public DicomCEchoResponse OnCEchoRequest(DicomCEchoRequest request, DicomPresentationContext presentationContext)
        {
            return new DicomCEchoResponse(request, DicomStatus.Success);
        }
    }
}