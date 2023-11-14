using Godot;
using System;
using System.Collections.Generic;

//Author : Leandre Chretiennot
namespace Com.IsartDigital.ProjectName.Managers
{
    public class PlayerManager : Manager
    {
        static private PlayerManager instance;

        protected PackedScene packedScene;
        protected List<PlayerManager> list;
		
		static public new PlayerManager GetInstance () {
			if (instance == null) instance = new PlayerManager();
		    return instance;
		}

        private PlayerManager () {}

        public override void Init(PackedScene pPackedScene, Main pGameContext)
        {
            packedScene = pPackedScene;
            list = new List<PlayerManager> ();
            gameContext = pGameContext;
        }

        public override void GameStart()
        {
            EmitSignal(nameof(ManagerReady));
        }

        public override Node CreateOne()
        {
            return packedScene.Instance();
        }

        public override T CreateOne<T>()
        {
            return (T)(object)packedScene.Instance();
        }

        public override void DoAction(float pDelta)
        {
            foreach (PlayerManager element in list)
            {
            }
        }
    }
}