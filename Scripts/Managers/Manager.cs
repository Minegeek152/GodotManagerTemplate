using Godot;
using System;
using System.Collections.Generic;

//Author : Leandre Chretiennot
namespace Com.IsartDigital.ProjectName.Managers
{
    public class Manager : Node
	{
		[Signal] public delegate void ManagerReady();

		static private Manager mainManagerInstance;
		protected Main gameContext;
		protected RandomNumberGenerator rand;

		private List<Manager> managers;

		private int managerReadyCount = 0;

		static public Manager GetInstance()
		{
			if (mainManagerInstance == null) mainManagerInstance = new Manager();
			return mainManagerInstance;
		}

		protected Manager() : base()
		{
			rand = new RandomNumberGenerator();
			rand.Randomize();
		}

		public void Init(Main pGameContext, PackedScene pPlayerScene)
		{
			gameContext = pGameContext;

			managers = new List<Manager>();

			// PlayerManager lPlayerManager = PlayerManager.GetInstance();
			// lPlayerManager.Init(pPlayerScene, gameContext);
			// managers.Add(lPlayerManager);

			foreach (Manager manager in managers)
			{
				manager.Connect(nameof(ManagerReady), this, nameof(ManagerIsReady));
			}

			gameContext.Connect("GameStartEventHandler", this, nameof(GameStart));
		}

		public virtual void Init(PackedScene pScene, Main pGameContext) { }

		public virtual T CreateObject<T>()
		{
			return (T)new object();
		}

		public virtual Node CreateObject()
		{
			return new Node();
		}

		public virtual void CreateMany(int pNumber)
		{
			for (int i = 0; i < pNumber; i++)
			{
				CreateObject();
			}
		}

		public virtual void GameStart()
		{
			foreach (Manager manager in managers)
			{
				manager.GameStart();
			}
		}

		public virtual void DoAction(float pDelta)
		{
			foreach (Manager manager in managers)
			{
				manager.DoAction(pDelta);
			}
		}

		protected void ManagerIsReady()
		{
			managerReadyCount++;
			GD.Print("MANAGER READY : " + managerReadyCount);
			if (managerReadyCount == managers.Count)
			{
				gameContext.GameIsReady();
			}
		}
	}
}
