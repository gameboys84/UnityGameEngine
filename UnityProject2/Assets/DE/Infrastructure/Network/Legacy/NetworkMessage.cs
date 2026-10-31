using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scpp;

public class NetworkMessage{// : ExtraData{

    public delegate void MessageHandlerType(NetworkMessage msg);
    public string m_socketName = "defaultSocket";
    Protocol.MsgType m_type;
    public int m_nodId;
    public IStubNetworkMessage m_IStubNetworkMessage; //for hotfix

    public NetworkMessage() { }
    
    public NetworkMessage(IStubNetworkMessage mIStubNetworkMessage)
    {
        m_IStubNetworkMessage = mIStubNetworkMessage;
    }
    
    public void SetMessageType(Protocol.MsgType type)
    {
        m_type = type;
    }

    public Protocol.MsgType GetMessageType()
    {
        return m_type;
    }
    
    public virtual void Decode(SPack sp)
    {
        if (m_IStubNetworkMessage != null)
        {
            m_IStubNetworkMessage.Decode(sp);
            // DLog.Log("Hotfix Decode!");
        }
        else
        {
            DLog.Error("Empty Decode!");
        }
    }

    public virtual void Encode(SPack sp)
    {
        if (m_IStubNetworkMessage != null)
        {
            m_IStubNetworkMessage.Encode(sp);
            // DLog.Log("Hotfix Encode!");
        }
        else
        {
            DLog.Error("Empty Encode!");
        }
    }
}
