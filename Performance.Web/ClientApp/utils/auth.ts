class Auth {
    private url: string = "/token";

    public signIn(username: string, password: string): Promise<void> {
        var info:RequestInfo = this.url;
        var init:RequestInit = {
            method: 'post',
            mode: 'no-cors',
            body: "username=" + username + "&password=" + password + "&grant_type=password&client_id=dotnetifydemo",
            headers: new Headers({ 'Content-Type': 'application/x-www-form-urlencoded;charset=UTF-8' }),
        };
        
        return fetch(info, init)
            .then(response => {
                if (!response.ok) throw new Error("" + response.status);
                return response.json();
            })
            .then(token => {
                window.localStorage.setItem("access_token", token.access_token);
            });
    }

    public signOut(): void {
        window.localStorage.removeItem("access_token");
        window.location.href = "/";
    }

    public getAccessToken(): string | null {
        return window.localStorage.getItem("access_token");
    }

    public hasAccessToken(): boolean {
        return this.getAccessToken() !== null;
    }
}

export default new Auth();