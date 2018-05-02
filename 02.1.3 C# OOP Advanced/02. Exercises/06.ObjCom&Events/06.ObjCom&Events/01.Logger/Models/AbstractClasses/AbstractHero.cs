using System;
public abstract class AbstractHero : IAttacker
{
    private const string TARGET_NULL_MESSAGE = "Target is null.";
    private const string NO_TARGET_MESSAGE = "{0} has no target.";
    private const string TARGET_DEAD_MESSAGE = "{0} is dead.";
    private const string SET_TARGET_MESSAGE = "{0} targets {1}.";

    private string id;
    private int damage;
    private ITarget target;
    private IHandler logger;

    public IHandler Logger
    {
        get => this.logger;
        private set => this.logger = value;
    }


    protected AbstractHero(string id, int damage, IHandler logger)
    {
        this.id = id;
        this.damage = damage;
        this.Logger = logger;
    }

    public void Attack()
    {
        if(this.target == null)
        {
            this.logger.Handle(LogType.ATTACK,string.Format(NO_TARGET_MESSAGE,this));
        }
        else if(this.target.IsDead)
        {
            this.logger.Handle(LogType.ATTACK,string.Format(TARGET_DEAD_MESSAGE,this.target));
        }
        else
        {
            this.ExecuteClassSpecificAttack(this.target, this.damage);
        }
    }

    public void SetTarget(ITarget target)
    {
        if(target == null)
        {
            this.logger.Handle(LogType.TARGET,string.Format(TARGET_NULL_MESSAGE));
        }
        else
        {
            this.target = target;

            this.logger.Handle(LogType.TARGET,string.Format(SET_TARGET_MESSAGE,this,target));
        }
    }

    protected abstract void ExecuteClassSpecificAttack(ITarget target, int damage);

    public override string ToString()
    {
        return this.id;
    }
}
