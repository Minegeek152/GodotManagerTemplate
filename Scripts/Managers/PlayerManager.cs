using Godot;
using System;
using System.Collections.Generic;

//Author : Sophia Solignac
//Credits to Leandre Chretiennot for the template
namespace Com.IsartDigital.ProjectName.Managers
{
    public class PlayerManager : Manager
    {
        static private PlayerManager instance;

        protected PackedScene packedScene;

        //Object monitored by this controller are stored here : Change to match your needs
        protected List<Node> list;

        static public new PlayerManager GetInstance () {
			if (instance == null) instance = new PlayerManager();
		    return instance;
		}

        private PlayerManager () {}

        public override void Init(PackedScene pPackedScene, Main pGameContext)
        {
            packedScene = pPackedScene;
            list = new List<Node>();
            gameContext = pGameContext;
        }

        public override void GameStart()
        {
            EmitSignal(nameof(ManagerReady));
        }

        public override Node CreateObject()
        {
            return packedScene.Instance();
        }

        public override T CreateObject<T>()
        {
            return (T)(object)packedScene.Instance();
        }

        public override void DoAction(float pDelta)
        {
            foreach (Node element in list)
            {

            }
        }
    }
}