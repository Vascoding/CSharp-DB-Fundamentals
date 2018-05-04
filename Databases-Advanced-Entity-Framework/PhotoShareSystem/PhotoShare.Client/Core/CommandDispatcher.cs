using System.Data.Entity;
using System.Linq;
using PhotoShare.Client.Core.Commands;
using PhotoShare.Services;


namespace PhotoShare.Client.Core
{
    using System;

    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            var commandName = commandParameters[0];
            commandParameters = commandParameters.Skip(1).ToArray();
            var result = "";

            UserService userService = new UserService();
            TownService townService = new TownService();
            TagService tagService = new TagService();
            AlbumService albumService = new AlbumService();

            switch (commandName)
            {
                case "RegisterUser":
                    RegisterUserCommand registerUser = new RegisterUserCommand(userService);
                    result = registerUser.Execute(commandParameters);
                    break;
                case "AddTown":
                    AddTownCommand addTown = new AddTownCommand(new TownService());
                    result = addTown.Execute(commandParameters);
                    break;
                case "ModifyUser":
                    ModifyUserCommand modifyUser = new ModifyUserCommand(userService, townService);
                    result = modifyUser.Execute(commandParameters);
                    break;
                case "DeleteUser":
                    DeleteUser deleteUser = new DeleteUser(userService);
                    result = deleteUser.Execute(commandParameters);
                    break;
                case "AddTag":
                    AddTagCommand addTag = new AddTagCommand(tagService);
                    result = addTag.Execute(commandParameters);
                    break;
                case "CreateAlbum":
                    CreateAlbumCommand createAlbum = new CreateAlbumCommand(userService, tagService, albumService);
                    result = createAlbum.Execute(commandParameters);
                    break;
                case "AddTagTo":
                    AddTagToCommand addTagTo = new AddTagToCommand(albumService, tagService);
                    result = addTagTo.Execute(commandParameters);
                    break;
                case "MakeFriends":
                    MakeFriendsCommand addFriend = new MakeFriendsCommand(userService);
                    result = addFriend.Execute(commandParameters);
                    break;
                case "ListFriends":
                    PrintFriendsListCommand listFriends = new PrintFriendsListCommand(userService);
                    result = listFriends.Execute(commandParameters);
                    break;
                case "ShareAlbum":
                    ShareAlbumCommand shareAlbum = new ShareAlbumCommand(albumService, userService);
                    result = shareAlbum.Execute(commandParameters);
                    break;
                case "UploadPicture":
                    UploadPictureCommand uploadPicture = new UploadPictureCommand(albumService);
                    result = uploadPicture.Execute(commandParameters);
                    break;
                case "Login":
                    LoginCommand loginCommand = new LoginCommand();
                    result = loginCommand.Execute(commandParameters);
                    break;
                case "Logout":
                    LogoutCommand logout = new LogoutCommand();
                    result = logout.Execute(commandParameters);
                    break;
                case "Exit":
                    ExitCommand exit = new ExitCommand();
                    exit.Execute();
                    break;
                default:
                    throw new InvalidOperationException($"Command {commandName} not valid!");

            }

            return result;
        }
    }
}
