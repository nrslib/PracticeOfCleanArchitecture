using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp {
    public class MessageBus {
        public static MessageBus Instance { get; }

        static MessageBus() {
            Instance = new MessageBus();
        }

        private readonly List<object> handlers = new List<object>();

        public void Send<T>(T message) {
            var handlers = this.handlers.OfType<IHandler<T>>();
            foreach (var handler in handlers) {
                handler.Handle(message);
            }
        }

        public void RegisterHandler(object handler) {
            handlers.Add(handler);
        }

        public void RemoveHanler(object handler) {
            handlers.RemoveAll(x => x.Equals(handler));
        }
    }
}
