public interface IInteractable
{
    public string InteractionPrompt { get; set; }
    public bool Interact(Interactor interactor);
}
